import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { DenBlService } from '../den-bl.service';
import { DenIzvod } from '../den-izvod.model';
import { Doc } from '../doc.model';
import { Smetka } from '../smetka.model';


@Component({
  selector: 'app-den-izvod',
  templateUrl: './den-izvod.component.html',
  styleUrls: ['./den-izvod.component.css']
})
export class DenIzvodComponent implements OnInit {
  
  subscription: Subscription
  docSmetki: Smetka[]
  izvod: DenIzvod = null
  
  pocetnoSaldo: number
  vkupnaIsplata: number
  vkupenPriem: number
  saldo: number
  documents: Doc[] = [];
  showAddIzvodbutton = false;
  kasaIspPatarini: Doc[] = [];
  kasaIspTerminal: Doc[] = [];
  kasaIspDrOsnov: Doc[] = [];
  kasaIspAvans: Doc[] = [];
  kasaPrimiAvans: Doc[] = [];
  kasaPrimiBanka: Doc[] = [];

 

  constructor(private denBlService: DenBlService) { }

  ngOnInit(): void {
    this.denBlService.getDenIzvod().subscribe();
    this.subscription = this.denBlService.denIzvodAdded
      .subscribe((izvod: DenIzvod) => {
        this.izvod = izvod
      })
    this.izvod = this.denBlService.getIzvod();
    this.documents = this.denBlService.getDocuments();
    console.log(this.izvod);
 
    this.kasaIspPatarini = this.documents.filter(x=> x.vidDocument == 1)
    this.kasaIspTerminal = this.documents.filter(x=> x.vidDocument == 2)
    this.kasaIspDrOsnov = this.documents.filter(x=> x.vidDocument == 3)
    this.kasaIspAvans = this.documents.filter(x=> x.vidDocument == 4)
    this.kasaPrimiAvans = this.documents.filter(x=> x.vidDocument == 5)
    this.kasaPrimiBanka = this.documents.filter(x=> x.vidDocument == 6)
    
    this.vkupenPriem = this.izvod.vkupenPriem;
    this.vkupnaIsplata = this.izvod.vkupnaIsplata
    this.pocetnoSaldo = this.izvod.denBlSostojba
    this.saldo = this.izvod.saldo 

    
      console.log(this.izvod);
      
    
    
    if ( this.documents.length > 0){
      this.showAddIzvodbutton = true
    }
  }



  onAddIzvod(){
    // const newIzvodDocumenti = [...this.documents]
    // //const newIzvod: DenIzvod = new DenIzvod(++this.denBlService.izvodId,  newIzvodDocumenti )
    // this.denBlService.addIzvod(newIzvod)
    // this.denBlService.pocetnosaldo = this.saldo
    // this.denBlService.vkupenPriem = 0;
    // this.denBlService.vkupnaIsplata = 0;
    // this.izvod =  this.denBlService.getLastIzvod()

   // stavi ruta do izvod/:id za da moze da se printa
   // ako e na id strana neka gi zeme documentite od pusteniot izvod
   //funkcija za koi dokumenti da se zemat b

    //this.izvod.finalIzvod = true;
    //this.izvod.izvodDate = new Date(Date.now()).toISOString()
   console.log(`--------------------------------`);
   console.log(`${this.izvod.izvodDate}`);
   console.log(`${this.izvod.vkupenPriem}`);
   console.log(`${this.izvod.vkupnaIsplata}`);
   console.log(`${this.izvod.id}`);
   console.log(`${this.izvod.finalIzvod}`);
   
  let izvodToUpdate: DenIzvod =this.denBlService.getIzvod() 

   //let izvodToUpdate: DenIzvod;
  let updateIzvod = new DenIzvod(new Date(Date.now()).toISOString(), +izvodToUpdate.vkupnaIsplata, +izvodToUpdate.vkupenPriem, +izvodToUpdate.saldo, +izvodToUpdate.denBlSostojba, true)
  updateIzvod.id = izvodToUpdate.id
  updateIzvod.denDocuments = this.documents;

  console.log(updateIzvod);
  
  this.denBlService.updateDenIzvod(updateIzvod);
  
  let newIzvod: DenIzvod = new DenIzvod(new Date(Date.now()).toISOString(),0,0,0,this.izvod.saldo,false)
  newIzvod.denDocuments = [];
  console.log(newIzvod);
  
  this.denBlService.addDenIzvod(newIzvod)

  }
  
  onPrintIzvod(){
    window.print()
  }

}
