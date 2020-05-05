import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BoardEmptyNoticeComponent } from './board-empty-notice.component';

describe('BoardEmptyNoticeComponent', () => {
  let component: BoardEmptyNoticeComponent;
  let fixture: ComponentFixture<BoardEmptyNoticeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoardEmptyNoticeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoardEmptyNoticeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
