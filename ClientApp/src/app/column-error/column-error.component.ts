import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-column-error',
  templateUrl: './column-error.component.html',
  styleUrls: ['./column-error.component.css']
})
export class ColumnErrorComponent implements OnInit {

  @Input()
  public error: string;

  constructor() { }

  ngOnInit() {
  }

}
