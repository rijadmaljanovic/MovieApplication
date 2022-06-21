import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/core/common/base.component';

@Component({
  selector: 'app-movie-home',
  templateUrl: './movie-home.component.html',
  styleUrls: ['./movie-home.component.css']
})
export class MovieHomeComponent extends BaseComponent implements OnInit {

constructor(injector:Injector) {
  super(injector);
  
}
  ngOnInit(): void {
  }

}
