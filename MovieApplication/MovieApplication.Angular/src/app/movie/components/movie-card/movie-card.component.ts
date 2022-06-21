import { Component, Injector, Input, OnInit,VERSION  } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { takeUntil } from 'rxjs';
import { BaseComponent } from 'src/app/core/common/base.component';
import { MovieModel } from 'src/app/core/models/data-models';
import { MovieService } from 'src/app/core/services/data-services/movie.service';
import { MovieModalComponent } from '../movie-modal/movie-modal.component';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent extends BaseComponent implements OnInit {
  
  @Input() movie:MovieModel =new MovieModel;

  constructor(injector:Injector,public modalService: NgbModal) {
    super(injector);
  }
  
  openModal(){
    var movieID=this.movie.id;
    const modalRef = this.modalService.open(MovieModalComponent);
    modalRef.componentInstance.movieID=movieID;
  }

  ngOnInit(): void {

  }

}
