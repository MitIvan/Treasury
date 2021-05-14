
import { Injectable } from "@angular/core";
import { from, Subject } from "rxjs";
import { Pe } from "../shared/pe.model";
import { Vraboten } from "../shared/vraboten.model";
import { DenIzvod } from "./den-izvod.model";
import { Doc } from "./doc.model";
import { Smetka } from "./smetka.model";
import { HttpClient } from '@angular/common/http'
import { tap } from 'rxjs/operators'

@Injectable()
export class DenBlService {

    constructor(private http: HttpClient){}

    pocetnosaldo: number = 1000000;
    vkupnaIsplata: number = 0;
    vkupenPriem: number = 0;

    documentsAdded = new Subject<Doc[]>();
    denIzvodAdded = new Subject<DenIzvod>();

    
    presmetkovni: Pe[] = []

    vraboteni: Vraboten[] = [] 
    

    documenti = [];
    

    izvod: DenIzvod
    

    getDocuments() {
        return this.documenti
    }

    getDocument(id: number) {
       return this.documenti.find(doc => doc.id === id)
    }


    getIzvod() {
        return this.izvod
    }

    calVkupnaIsplata(): number {
        for(let x of this.getDocuments()){
            if(x.vidDoc == 1 || x.vidDoc == 2 || x.vidDoc == 3 || x.vidDoc == 4){
                this.vkupnaIsplata += x.totalSmetki 
            }
        } 

        return this.vkupnaIsplata  
    }

    calVkupenPrimi() :number {
        for(let x of this.getDocuments()){
            if(x.vidDoc == 5 || x.vidDoc == 6) {
                this.vkupenPriem +=  x.totalSmetki
            }
        }

        return this.vkupenPriem
        
    }

    setDocuments(documents: Doc[]){
    console.log(documents);
      this.documenti = documents;
      
      this.documentsAdded.next(this.documenti)  
    }

    setIzvod(denIzvod: DenIzvod){
        console.log(denIzvod);
        this.izvod = denIzvod
        this.denIzvodAdded.next({...this.izvod});
        console.log(denIzvod);
        
      
    }

    getDenDocuments() {
        return this.http.get<Doc[]>('https://localhost:44325/api/dendocument')
            .pipe(tap(documents => this.setDocuments(documents)))
    }

    getPresmetkovniEd() {
        this.http.get<Pe[]>('https://localhost:44325/api/presmetkovna')
            .subscribe(presmetkovni => this.presmetkovni = presmetkovni)       
    }

    getVraboteni() {
        this.http.get<Vraboten[]>('https://localhost:44325/api/vraboten')
            .subscribe(vraboteni => this.vraboteni = vraboteni)       
    }

    getDenIzvod() {
       return this.http.get<DenIzvod>('https://localhost:44325/api/denizvod/lastizvod')
            .pipe(tap(denIzvod => {this.setIzvod(denIzvod)}))
    } 

    addDocument(document: Doc) {
        this.http.post('https://localhost:44325/api/dendocument', document)
            .subscribe()
    }
    
    updateDocument(newDocument: Doc) {
        this.http.put('https://localhost:44325/api/dendocument', newDocument)
        .subscribe()
    }

    deleteDocument(id: number) {
        this.http.delete(`https://localhost:44325/api/dendocument/${id}`).subscribe();
    }

    addDenIzvod(newIzvod: DenIzvod) {
        this.http.post('https://localhost:44325/api/denizvod', newIzvod)
        .subscribe()
    }

    updateDenIzvod(newIzvod: DenIzvod) {
        this.http.put('https://localhost:44325/api/denizvod', newIzvod)
        .subscribe(res => console.log(res)
        )
    }
}
