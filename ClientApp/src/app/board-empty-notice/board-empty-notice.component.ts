import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-board-empty-notice',
  templateUrl: './board-empty-notice.component.html',
  styleUrls: ['./board-empty-notice.component.css']
})
export class BoardEmptyNoticeComponent implements OnInit {
  @Input()
  public boardId;

  constructor() { }

  ngOnInit() {
  }

}
