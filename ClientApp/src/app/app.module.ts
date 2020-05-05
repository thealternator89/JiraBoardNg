import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { StatusColumnComponent } from './status-column/status-column.component';
import { TicketCardComponent } from './ticket-card/ticket-card.component';
import { BoardEmptyNoticeComponent } from './board-empty-notice/board-empty-notice.component';
import { ColumnErrorComponent} from './column-error/column-error.component';

@NgModule({
  declarations: [
    AppComponent,
    BoardEmptyNoticeComponent,
    ColumnErrorComponent,
    StatusColumnComponent,
    TicketCardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
