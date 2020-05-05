import {Component, Inject, Input, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-status-column',
  templateUrl: './status-column.component.html',
  styleUrls: ['./status-column.component.css']
})
export class StatusColumnComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  @Input()
  public status: { title: string, bgColor: string, filterId: number, filterUrl: string };

  public tickets: any[];

  public error: string;

  ngOnInit() {
    this.http.get(this.baseUrl + 'filter?id=' + this.status.filterId).subscribe(result => {
      this.tickets = result as any[];
    }, error => this.error = error.message);
  }

}
