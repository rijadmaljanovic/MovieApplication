import { Component, Injector, Input, OnInit } from '@angular/core';
import { takeUntil } from 'rxjs';
import { BaseComponent } from 'src/app/core/common/base.component';
import { MovieDetailsModel } from 'src/app/core/models/data-models';
import { MovieService } from 'src/app/core/services/data-services/movie.service';
import { ToastrService } from 'ngx-toastr';
import { AppConstants } from 'src/app/core/common/app-constants';
@Component({
  selector: 'movie-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent extends BaseComponent implements OnInit {

  stars: number[] = [1, 2, 3, 4, 5];
  selectedValue: number = 0;
  isMouseover = true;

@Input() movie: MovieDetailsModel;

constructor(injector: Injector,private movieService:MovieService, private toastr: ToastrService ) {
  super(injector);
 
}

  ngOnInit(): void {
  }

  addClass(star: number) {
    if (this.isMouseover) {
      this.selectedValue = star;
    }
   }
  
   removeClass() {
     if (this.isMouseover) {
        this.selectedValue = 0;
     }
    }

  onRateChange(newRating:number){
    
  this.isMouseover = false;
  this.selectedValue = newRating;

    this.movieService.rateMovie(this.movie.id,newRating)
    .pipe(takeUntil(this.unsubscribe$))
    .subscribe(
      (res)=>{
        this.movie=res;
        this.toastr.success(AppConstants.movie_rated_success);
      },
      (err)=>{
        this.toastr.error(AppConstants.error_user_message);
      });
  }
}
