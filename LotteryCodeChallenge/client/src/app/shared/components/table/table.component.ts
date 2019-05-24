import { Component, OnInit, AfterViewInit, ViewChild, Input } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { DrawRequest } from '../../models/DrawRequest';
import { HttpService } from '../../services/http.service';
import { ITable } from '../../models/ITable';
import { SnackNotificationService } from '../../services/notifications/notification.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @Input() TableSource: string;
  dataSource: any;

  displayedColumns: string[] = [];

  companyName: string;
  maxDrawCount: number;

  constructor(private httpService: HttpService<ITable>, protected notifier: SnackNotificationService) {
    this.companyName = 'Tattersalls';
    this.maxDrawCount = 10;
  }

  ngOnInit() {
    this.displayedColumns = this.getColumns().map((c) => c.prop);
    this.refreshData();
  }

  refreshData() {
    console.log('Getting data from:' + this.TableSource);
    const request = new DrawRequest();
    request.CompanyId = this.companyName;
    request.MaxDrawCount = this.maxDrawCount;

    if (this.TableSource === 'current') {
      const response = this.httpService.SendPost('/current', request);
      response.subscribe(
        (data) => {
          console.log('got data...');
          console.log(data);
          this.dataSource = new MatTableDataSource(data);
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
          this.notifier.notify('Current Draws Data Refreshed');
        },
        (error) => {
          this.notifier.notifyError(error, null);
        },
        // Complete
        () => {
          console.log('complete current data fetch');
        });
      return null;
    }
    if (this.TableSource === 'open'){
      const response = this.httpService.SendPost('/open', request);
      response.subscribe(
        (data) => {
          console.log('got data...');
          console.log(data);
          this.dataSource = new MatTableDataSource(data);
          this.notifier.notify('Open Draws Data Refreshed');
        },
        (error) => {
          this.notifier.notifyError(error, null);
        },
        // Complete
        () => {
          console.log('complete current data fetch');
        });
      return null;
    }
  }

  getColumns() {
    return [
      {
        prop: 'drawLogoUrl'
      },
      {
        prop: 'drawDisplayName',
        name: 'Draw Name'
      },
      {
        prop: 'drawNumber',
        name: 'Draw Number'
      },
      {
        prop: 'drawDate',
        name: 'Draw Date'
      },
      {
        prop: 'div1Amount',
        name: 'Jackpot Value'
      }
    ];
  }
}
