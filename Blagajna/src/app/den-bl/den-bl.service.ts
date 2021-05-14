
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

// Static Db--------------------------------------------------
    //docId: number = 4
    
    presmetkovni: Pe[] = [
        // new Pe ('000', 'Oilco'),
        // new Pe ('123', "SK-123-UU Iveco"),
        // new Pe ('133', "SK-624-UU Iveco"),
        // new Pe ('113', "SK-143-UU Iveco"),
    ]

    vraboteni: Vraboten[] = [
        // new Vraboten(190, 'Ivan Mitev'),
        // new Vraboten(200, 'Ivan Mitev1'),
        // new Vraboten(300, 'Ivan Mitev2'),
        // new Vraboten(400, 'Ivan Mitev3'),
    ] 
    

     documenti = 
        [
            // new Doc(1, "21.11.2021", 1, this.presmetkovni[1], this.vraboteni[1],'', [new Smetka( '2343523','07.01.2020' , 5000), new Smetka('1234', '11.11.2020', 2000)]),
            
            // new Doc(2, "21.11.2021", 2, this.presmetkovni[2], this.vraboteni[2], 'Терминал', [new Smetka('1232314', '29.12.2020', 2000), new Smetka('122314', '29.12.2020', 200)]),
           
            // new Doc(3, "21.11.2021", 3, this.presmetkovni[3], this.vraboteni[3], '', [new Smetka('124564', '30.12.2020', 6000)]),
            
            // new Doc(4, "21.11.2021", 1, this.presmetkovni[2], this.vraboteni[1], '', [new Smetka('125664', '30.12.2020', 4000)]),
        ];
    

    izvod: DenIzvod
    
    // izvodId: number = 0;
    // private izvodi: DenIzvod[] = [ ];

//--------------------------------------------------------------------------------

    //funkcija koja koga ke se proknizi izvodot ke ja smeni vrednosta na posledniot izvod proknizen:false vo true
    //i ke kreira nov izvod
    //private izvod: DenIzvod = new DenIzvod(123, this.documenti);
    
    //-----------------------------------------------------------------

    getDocuments() {
        return this.documenti
    }

    getDocument(id: number) {
       return this.documenti.find(doc => doc.id === id)
    }

    //--------------------------------------------------------------------------------------

    getIzvod() {
        return this.izvod
    }

    // getLastIzvod(){
    //    return this.izvodi[this.izvodi.length-1]
    // }

    // addIzvod(izvod: DenIzvod) {
    //     this.izvodi.push(izvod)
    //     this.documenti = []
    //     console.log(this.izvodi);
        
    // }

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
