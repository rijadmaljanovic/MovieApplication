import { Component, Injector, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from 'src/app/core/common/base.component';
import { MovieDetailsComponent } from '../movie-details/movie-details.component';

@Component({
  selector: 'app-movie-modal',
  templateUrl: './movie-modal.component.html',
  styleUrls: ['./movie-modal.component.css']
})
export class MovieModalComponent extends BaseComponent implements OnInit {

  @Input() movieID:number;

  constructor(injector:Injector, private activeModal: NgbActiveModal) {
    super(injector)
   }

  ngOnInit(): void {
  }

  closeModal() {
    this.activeModal.close();
  }
}
