import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DenBlService } from '../den-bl.service';
import { Doc } from '../doc.model';

@Component({
  selector: 'app-den-list',
  templateUrl: './den-list.component.html',
  styleUrls: ['./den-list.component.css']
})
export class DenListComponent implements OnInit {
  documents: Doc[];
  subscription: Subscription

  constructor(private denBlService: DenBlService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.denBlService.getDenDocuments().subscribe();
    this.subscription = this.denBlService.documentsAdded
      .subscribe((documents: Doc[]) => {
        this.documents = documents
      })
    this.documents = this.denBlService.getDocuments();
    console.log(this.documents);
    
  }

  onNewDoc(){
    this.router.navigate(['new'], {relativeTo: this.route})
  }


}
