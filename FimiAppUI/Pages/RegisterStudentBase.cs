﻿using Azure;
using Microsoft.AspNetCore.Components.Forms;
using System.Data;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace FimiAppUI.Pages
{
    public class RegisterStudentBase : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Inject] public IFormService FormService { get; set; }
        [Inject] public IStreamService StreamService { get; set; }
        [Inject] public IStudentService StudentService { get; set; }
        [Inject] public IParentService ParentService { get; set; }
        [Inject] public IParentStudentService ParentStudentService { get; set; }
        [Inject] public IDialogService DialogService { get; set; }
        [Inject] public ISnackbar Snackbar { get; set; }
        public FileModelFluentValidator FileValidator { get; set; } = new FileModelFluentValidator();
        public StudentModelFluentValidator StudentValidator { get; set; } = new StudentModelFluentValidator();
        public ParentModelFluentValidator ParentValidator { get; set; } = new ParentModelFluentValidator();
        public StudentModel Student { get; set; } = new StudentModel();
        public ParentModel Parent { get; set; } = new ParentModel();
        public FormModel NewStudentForm { get; set; }
        public StreamModel NewStudentStream { get; set; }
        public string SelectedGender { get; set; }
        public string ModelFail { get; set; }
        public string ModelSuccess { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public string ContentText { get; set; }
        public string ButtonText { get; set; }
        public DialogOptions dialogOptions = new() { FullWidth = true };    
        public DateTime newStudentDateOfBirth;
        public MudForm registerStudentForm;
        public MudForm registerParentForm;
        public MudDialog registerDialog;
        public bool showSuccessAlert = false;
        public bool showFailAlert = false;
        public bool visible;
        public MudForm form;
        public FileModel model = new();
        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        public async Task<IEnumerable<FormModel>> FormSearch(string value)
        {
            return (await FormService.GetForms()).ToList();
        }
        public async Task<IEnumerable<StreamModel>> StreamSearch(string value)
        {
            return (await StreamService.GetStreams()).ToList();
        }
        public async Task Submit()
        {
            visible = true;
        }
        public async Task DialogSubmit()
        {
            visible = false;

            await registerStudentForm.Validate();
            await registerParentForm.Validate();
            if (registerStudentForm.IsValid && registerParentForm.IsValid)
            {
                var studentResponse = await StudentService.AddStudent(Student);
                var parentResponse = await ParentService.AddParent(Parent);
                if (studentResponse.StatusCode == HttpStatusCode.Created && parentResponse.StatusCode == HttpStatusCode.Created)
                {
                    var parentStudentResponse = await ParentStudentService.AddParentStudent(Parent);
                    if(parentStudentResponse.StatusCode == HttpStatusCode.Created)
                    {
                        ShowSuccessAlert($"\"{Student.StudentName()}\" has been added and \"{Parent.FirstName} {Parent.Surname}\" linked as the parent");
                    }
                }
                else if(parentResponse.StatusCode == HttpStatusCode.Conflict)
                {
                    var parentStudentResponse = await ParentStudentService.AddParentStudent(Parent);
                    if (parentStudentResponse.StatusCode == HttpStatusCode.Created)
                    {
                        ShowSuccessAlert($"\"{Student.StudentName()}\" has been added and \"{Parent.FirstName} {Parent.Surname}\" linked as the parent");
                    }
                }
                else
                {
                    ShowFailAlert($"Failed to add student!");
                }
            }
            await registerStudentForm.ResetAsync();
            await registerParentForm.ResetAsync();
        }
        public void UploadFiles(InputFileChangeEventArgs e)
        {
            using(var stream = model.File.OpenReadStream())
            {
                using(var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {
                    var conf = new
                }
            }
        }
        public async Task SubmitFileUpload()
        {
            await form.Validate();

            if (form.IsValid)
            {
                Snackbar.Add("Submited!");
            }
        }
        public void Cancel() => visible = false;
        public void ShowSuccessAlert(string modelType)
        {
            ModelSuccess = modelType;
            showSuccessAlert = true;
        }
        public void ShowFailAlert(string modelType)
        {
            ModelFail = modelType;
            showFailAlert = true;
        }
        public void CloseMe(bool value)
        {
            if (value)
            {
                showSuccessAlert = false;
                showFailAlert = false;
            }
            else
            {
                showSuccessAlert = false;
                showFailAlert = false;
            }
        }
    }
}