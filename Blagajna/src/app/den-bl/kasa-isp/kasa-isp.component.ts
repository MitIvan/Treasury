import { ReturnStatement } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Pe } from 'src/app/shared/pe.model';
import { Vraboten } from 'src/app/shared/vraboten.model';
import { DenBlService } from '../den-bl.service';
import { Doc } from '../doc.model';
import { formatDate } from '@angular/common';
import { asapScheduler } from 'rxjs';

@Component({
  selector: 'app-kasa-isp',
  templateUrl: './kasa-isp.component.html',
  styleUrls: ['./kasa-isp.component.css']
})
export class KasaIspComponent implements OnInit {
  id: number;
  editMode: boolean = false;
  docForm: FormGroup;
  voziloIme: string = "";
  vrabotenIme: string = "";

  get controls() { 
    return (<FormArray>this.docForm.get('denSmetki')).controls;
  }


  constructor(private route: ActivatedRoute, private router: Router, private denBlService: DenBlService) { }

  ngOnInit(): void { 
    this.route.params
      .subscribe(
        (params: Params) => {
          this.id = +params['id'];
          this.editMode = params['id'] != null;
          this.initForm();
        }
      )

      this.onGetVozilo();
      this.onGetVraboten()
     
  }



  //Da nema document id vo konstuctor 
  //vo submit da ima getDocById() za update. i posle updatedDocument.DocDate updatedDocument.pe za site

  onSubmit(){
    const date = new Date(Date.now()).toISOString()
    console.log(date);
    
    const izvodId = this.denBlService.izvod.id;
    const docToUpdate: Doc = this.denBlService.getDocument(this.id)

    const peId: number = this.denBlService.presmetkovni.find(x=> x.peNumber == this.docForm.value['peNumber']).id
    const vrabotenId: number = this.denBlService.vraboteni.find(x => x.mb == this.docForm.value['vrabotenMb']).id
    
    let documents = this.denBlService.documenti
    
    if (this.editMode) {
      let updatedDocument = new Doc (docToUpdate.docDate, +this.docForm.value['vidDocument'], peId, vrabotenId, docToUpdate.denIzvodId, this.docForm.value['zabeleska'], this.docForm.value['denSmetki'])
      updatedDocument.id = this.id;
      console.log(updatedDocument);
      
      this.denBlService.updateDocument(updatedDocument)
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([`/denbl/${this.id}`])}); 
    } else {
      const newDocument = new Doc (date, +this.docForm.value['vidDocument'], peId, vrabotenId, izvodId, this.docForm.value['zabeleska'], this.docForm.value['denSmetki'])
      this.denBlService.addDocument(newDocument)

      let idForNewDoc = documents[documents.length-1].id
      this.id = idForNewDoc + 1

      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigate([`/denbl/${this.id}`])}); 
    }
    
    // if(documents.length == 0){
    //   this.id = 1
    // }else {
    //   let idForNewDoc = documents[documents.length-1].id
    //   this.id = idForNewDoc + 1
    //   console.log(`${this.id} ssssssssssssss`);
      
    // }


    
    // this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
    // this.router.navigate([`/denbl/${this.id}`])}); 
  }

  onAddSmetka() {
    (<FormArray>this.docForm.get('denSmetki')).push(
      new FormGroup({
        'smetkaInfo': new FormControl(null, Validators.required),
        'smetkaDate': new FormControl(null,[Validators.required, Validators.pattern(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/)]),    
        'smetkaTotal': new FormControl(null,[Validators.required, Validators.pattern(/^[1-9]+[0-9]*$/)])  
      })
    )
  }

  onGetVozilo()  {
    const docPe: Pe = this.denBlService.presmetkovni.find(x=> x.peNumber == this.docForm.value['peNumber'])
    if( docPe) {
      this.voziloIme = docPe.peName
    } else {
      this.voziloIme = 'Нема таква премстковна '
    }
  }

  onGetVraboten()  {
    const docVraboten: Vraboten = this.denBlService.vraboteni.find(x=> x.mb == this.docForm.value['vrabotenMb'])
    if( docVraboten) {
      this.vrabotenIme = docVraboten.fullName
    } else {
      this.vrabotenIme = 'Нема таков матичен број '
    }
  }

  onDeleteSmetka(index: number) {
    (<FormArray>this.docForm.get('denSmetki')).removeAt(index)
  }


  private initForm() {
    let vidDocument = null;
    let peNumber = null;
    let vrabotenMb = null;
    let zabeleska = ''
    let smetkiArr = new FormArray([])

    
    if(this.editMode) {
      const document : Doc = this.denBlService.getDocument(this.id)
      vidDocument = document.vidDocument
      peNumber = document.peNumber
      vrabotenMb = document.vrabotenMb
      zabeleska = document.zabeleska
      if(document['denSmetki']) {
        for (let x of document.denSmetki) {
          smetkiArr.push(
            new FormGroup({
            'smetkaInfo': new FormControl(`${x.smetkaInfo}`, Validators.required),
            'smetkaDate': new FormControl(x.smetkaDate, [Validators.required,Validators.pattern(/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/) ]),    
            'smetkaTotal': new FormControl(x.smetkaTotal, [Validators.required, Validators.pattern(/^[1-9]+[0-9]*$/)
              ])    
            })
          )
        }
      }
    }

    this.docForm = new FormGroup({
      'vidDocument': new FormControl(vidDocument, Validators.required),
      'peNumber': new FormControl(peNumber, [Validators.required, this.checkPe.bind(this)]),
      'vrabotenMb': new FormControl(vrabotenMb, [Validators.required, this.checkVraboteni.bind(this)]),
      'zabeleska': new FormControl(zabeleska),
      'denSmetki': smetkiArr
    })
  }

  //validatori
  
  checkPe(control: FormControl): {[s: string]: boolean} {
    let peBroj = this.denBlService.presmetkovni.map(x=> x.peNumber).toString()
    if(peBroj.indexOf(control.value) !== -1) {
      return null
    }
    return {'Nema takava pe': true}
  }

  checkVraboteni(control: FormControl): {[s: string]: boolean} {
    let mbBroj = this.denBlService.vraboteni.map(x=> x.mb).toString()
    if(mbBroj.indexOf(control.value) !== -1) {
      return null
    }
    return {'Nema takava MB': true}
  }
  

}