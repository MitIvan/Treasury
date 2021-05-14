import { Component, OnInit } from '@angular/core';
import { DenBlService } from '../den-bl/den-bl.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private denBlService: DenBlService){}  

  ngOnInit(): void {
    this.denBlService.getPresmetkovniEd();
    this.denBlService.getVraboteni();
    
  }

}
