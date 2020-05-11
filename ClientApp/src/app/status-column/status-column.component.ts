import {Component, Inject, Input, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {TicketCardComponent} from "../ticket-card/ticket-card.component";

@Component({
  selector: 'app-status-column',
  templateUrl: './status-column.component.html',
  styleUrls: ['./status-column.component.css']
})
export class StatusColumnComponent implements OnInit {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  @Input()
  public status: { title: string, bgColor: string, filterId: number, filterUrl: string, wipLimit: number };

  public tickets: any[];

  public error: string;

  ngOnInit() {
    this.reloadData();
  }

  reloadData() {
    this.tickets = [];
    this.http.get(this.baseUrl + 'filter?id=' + this.status.filterId).subscribe(result => {
      this.tickets = result as any[];
    }, error => this.error = error.message);
  }

  getWipLimitClass() {
    const wipLimit = this.status.wipLimit;
    const cardCount = this.tickets.length;

    if (wipLimit == null || cardCount < wipLimit) {
      return 'badge-primary';
    } else if (wipLimit === cardCount) {
      return 'badge-secondary';
    } else {
      return 'badge-danger';
    }
  }

}
