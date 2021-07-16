import { Component } from '@angular/core';
import * as HighCharts  from 'highcharts-angular';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ChartClient';
  HighCharts : typeof  HighCharts= HighCharts;
  chartptions:  HighCharts.Options={
    title:{
      text:"Basliq",
    },
    subtitle:{
      text:"Basliq",
    }
  }
}
