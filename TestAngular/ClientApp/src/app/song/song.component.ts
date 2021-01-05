import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent implements OnInit {

  my_name = 'Windstorm';
  isShown = true;
  constructor() { }

  ngOnInit() {
    // my_name = "thay doi roi";
  }
  displayCities(){
    this.my_name = "thay doi";
  this.isShown = !this.isShown;
  }

  clickFunction() {

    alert("clicked me!");

  }
}
