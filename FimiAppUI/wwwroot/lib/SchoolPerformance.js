
window.setup = (Id, Labels, LabelF1N, LabelF1S, LabelF2N, LabelF2S, LabelF3N, LabelF3S, LabelF4N, LabelF4S,
                DataF1N, DataF1S, DataF2N, DataF2S, DataF3N, DataF3S, DataF4N, DataF4S) => {
    var ctx = document.getElementById(Id).getContext('2d');

    var chartData = {
        labels: Labels,
        datasets: [
            {
                label: LabelF1N,
                data: DataF1N,
                backgroundColor: '#006BA6',
            },
            {
                label: LabelF1S,
                data: DataF1S,
                backgroundColor: '#FFBC42',
            },
            {
                label: LabelF2N,
                data: DataF2N,
                backgroundColor: '#0496FF',
            },
            {
                label: LabelF2S,
                data: DataF2S,
                backgroundColor: '#8F2D56',
            },
            {
                label: LabelF3N,
                data: DataF3N,
                backgroundColor: '#A6808C',
            },
            {
                label: LabelF3S,
                data: DataF3S,
                backgroundColor: '#44AF69',
            },
            {
                label: LabelF4N,
                data: DataF4N,
                backgroundColor: '#FFEAEE',
            },
            {
                label: LabelF4S,
                data: DataF4S,
                backgroundColor: '#D64550',
            }
        ]
    };
    Chart.defaults.font.weight = 'bold';
    var options = {
        responsive: true,
        plugins: {
            colorschemes: {
                scheme: 'tableau.Tableau20'
            },
            legend: {
                position: 'bottom',
            },
            title: {
                display: true,
                text: 'School performance',
                color: '#000000'
            }
        }
    };

    var myClusteredColumnChart = new Chart(ctx, {
        type: "bar",
        data: chartData,
        options: options,
    });

};