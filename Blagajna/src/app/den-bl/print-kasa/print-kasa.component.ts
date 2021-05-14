import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { DenBlService } from '../den-bl.service';
import { Doc } from '../doc.model';

@Component({
  selector: 'app-print-kasa',
  templateUrl: './print-kasa.component.html',
  styleUrls: ['./print-kasa.component.css']
})
export class PrintKasaComponent implements OnInit {

  document: Doc;
  id: number;
  vidDocument: string;
  
  //ne e tocno da se sredi samo za testiranje
  today


  constructor(private denBlService: DenBlService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params
      .subscribe(
        (params: Params) => {
          this.id = +params['id']
          this.document = this.denBlService.getDocument(this.id)
          this.showVidDoc()
        }
      )
      
        /////!!!!!!
      this.today = Date.now();
  }

  showVidDoc(){
    switch (this.document.vidDocument) {
      case 1:
        this.vidDocument = 'Каса Исплати Патарини'
        break;
      case 2:
        this.vidDocument = 'Каса Исплати Патарини За Терминал/Шпедиција'
        break;
      case 3:
        this.vidDocument = 'Каса Исплати Патарини По Друг Основ'
        break;
      case 4:
        this.vidDocument = 'Каса Исплати Патарини За Аванс'
        break;
      case 5:
        this.vidDocument = 'Каса Прими За Вратен Аванс'
        break;
      case 6:
        this.vidDocument = 'Каса Прими Подигнати Средства Од Банка'
        break;
    
      default:
        break;
    }
  }

  onEditDoc() {
    this.router.navigate(['edit'], {relativeTo: this.route})
  }

  onDeleteDoc() {
    this.denBlService.deleteDocument(this.document.id)

    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
    this.router.navigate([`/denbl`])});    
  }
  
  onPrintKasa() {
    window.print()
  }
}
