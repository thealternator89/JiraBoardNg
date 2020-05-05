import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public board = { columns: [] };
  public boardId;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    const url = new URL(window.location.href);
    this.boardId = url.searchParams.get('board');

    http.get(`${baseUrl}board?id=${this.boardId}`).subscribe(result => {
      this.board = result as any;
    }, error => {
      this.board = { columns: [] };
    });
  }

}
