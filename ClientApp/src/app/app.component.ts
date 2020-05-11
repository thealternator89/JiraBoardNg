import {Component, Inject, QueryList, ViewChild, ViewChildren} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {StatusColumnComponent} from "./status-column/status-column.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public board = { boardName: '', columns: [] };
  public boardId;

  public error;

  @ViewChildren(StatusColumnComponent, {read: false, static: false}) columns: QueryList<StatusColumnComponent>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    const url = new URL(window.location.href);
    this.boardId = url.searchParams.get('board');

    http.get(`${baseUrl}board?id=${this.boardId}`).subscribe(result => {
      this.board = result as any;
    }, error => {
      this.error = error.message;
    });
  }

  reloadChildData() {
    this.columns.forEach((col) => col.reloadData());
  }

}
