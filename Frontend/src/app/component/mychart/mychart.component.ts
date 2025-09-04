import { Component, OnInit } from '@angular/core';
import { TripInfoList } from 'src/app/shared/_model/tripinfodata';
import { TripService } from 'src/app/services/trip.service';
import { Chart, ChartType } from 'chart.js/auto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mychart',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './mychart.component.html',
  styleUrls: ['./mychart.component.css'],
})

export class MychartComponent implements OnInit {
  chartdata: TripInfoList = [];
  labeldata: string[] = [];
  realdata: number[] = [];
  colordata: string[] = [];
  constructor(private service: TripService) {}

  ngOnInit(): void {
    this.loadChartData();
  }

  loadChartData() {
    this.service.loadTripData().subscribe((items: TripInfoList) => {
      this.chartdata = items;

      if (this.chartdata) {

        this.prepareChartData();
        this.renderBarChart();
        this.renderDoughnutChart();
      }
    });
  }

  prepareChartData(): void {
     this.labeldata = this.chartdata.map(trip => trip.storeName.trim());
     this.realdata = this.chartdata.map(trip => trip.yourEarnings);
     this.colordata = this.chartdata.map(() => this.getRandomColor());
  }

  getRandomColor(): string {
    return `#${Math.floor(Math.random() * 16777215).toString(16)}`;
  }


renderChart(
    chartId: string,
    chartType: ChartType,
    label: string,
    labels: string[],
    data: number[],
    backgroundColor: string[]
  ): void {
    new Chart(chartId, {
      type: chartType,
      data: {
        labels,
        datasets: [
          {
            label,
            data,
            backgroundColor,
            borderRadius: chartType === 'bar' ? 5 : 0,
            borderColor: chartType === 'line' ? 'rgba(75, 192, 192, 1)' : undefined,
            fill: chartType === 'line',
            tension: chartType === 'line' ? 0.3 : undefined,
          },
        ],
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            display: false,
            position: 'top',
          },
        },
        scales: chartType === 'bar' || chartType === 'line' ? {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: label,
            },
          },
          x: {
            title: {
              display: true,
              text: 'Store Name',
            },
          },
        } : {},
      },
    });
  }

renderBarChart(): void {
    this.renderChart('barchart', 'bar', 'Earnings ($)', this.labeldata, this.realdata, this.colordata);
  }

  renderDoughnutChart(): void {
    this.renderChart('doughnutchart', 'doughnut', 'Earnings ($)', this.labeldata, this.realdata, this.colordata);
  }

}
