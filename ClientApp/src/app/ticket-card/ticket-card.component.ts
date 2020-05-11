import {Component, Input, OnInit} from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-ticket-card',
  templateUrl: './ticket-card.component.html',
  styleUrls: ['./ticket-card.component.css']
})
export class TicketCardComponent implements OnInit {

  constructor() { }

  public selected = false;

  @Input()
  public details: {
    id: string,
    summary: string,
    assignee: {
      name: string,
      icon: string,
    },
    issueType: {
      text: string,
      icon: string
    },
    url: string,
    updated: string
  };

  public timeSinceUpdate: number;

  ngOnInit() {
    this.timeSinceUpdate = this.getTimeSinceUpdate();
  }

  getClasses() {
    return `ticket-card w-100 card ${this.selected ? 'text-white bg-dark' : ''}`;
  }

  click() {
    this.selected = !this.selected;
  }

  getTimeSinceUpdate(): number {
    const updated = moment(this.details.updated);
    const duration = moment.duration(updated.diff(moment()));
    const days = Math.abs(duration.asDays());
    return Math.round(days);
  }
}
