
import { Component, OnInit,  Input } from '@angular/core';
import { DenBlService } from '../../den-bl.service';
import { Doc } from '../../doc.model';

@Component({
  selector: 'app-den-item',
  templateUrl: './den-item.component.html',
  styleUrls: ['./den-item.component.css']
})
export class DenItemComponent implements OnInit {

  @Input() document: Doc;
  @Input() index: number
  

  
  constructor(private DenBlService: DenBlService) { }

  ngOnInit(): void {
    
  }

  

}
