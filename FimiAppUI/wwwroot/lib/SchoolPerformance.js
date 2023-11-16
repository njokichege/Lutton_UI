
window.setup = (Id, Labels, LabelF1N, LabelF1S, LabelF2N, LabelF2S, LabelF3N, LabelF3S, LabelF4N, LabelF4S,
                DataF1N, DataF1S, DataF2N, DataF2S, DataF3N, DataF3S, DataF4N, DataF4S) => {
    var ctx = document.getElementById(Id).getContext('2d');

    var chartData = {
        labels: Labels,
        datasets: [
            {
                label: LabelF1N,
                data: DataF1N,
                backgroundColor: '#78CDD7',
            },
            {
                label: LabelF1S,
                data: DataF1S,
                backgroundColor: '#A24936',
            },
            {
                label: LabelF2N,
                data: DataF2N,
                backgroundColor: '#D36135',
            },
            {
                label: LabelF2S,
                data: DataF2S,
                backgroundColor: '#4A051C',
            },
            {
                label: LabelF3N,
                data: DataF3N,
                backgroundColor: '#830A48',
            },
            {
                label: LabelF3S,
                data: DataF3S,
                backgroundColor: '#251101',
            },
            {
                label: LabelF4N,
                data: DataF4N,
                backgroundColor: '#006494',
            },
            {
                label: LabelF4S,
                data: DataF4S,
                backgroundColor: '#DA4167',
            }
        ]
    };
    Chart.defaults.font.weight = 'bold';
    var options = {
        responsive: true,
        plugins: {
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