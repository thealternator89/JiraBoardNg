import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-ticket-card',
  templateUrl: './ticket-card.component.html',
  styleUrls: ['./ticket-card.component.css']
})
export class TicketCardComponent implements OnInit {

  constructor() { }

  @Input()
  public details: { id: string, summary: string, assignee: string, issueType: { text: string, icon: string }, url: string };

  ngOnInit() {
  }

  getIssueTypeName() {
    // return this.details.issueType.replace(/\s+/g, '_');
    return '';
  }
}
