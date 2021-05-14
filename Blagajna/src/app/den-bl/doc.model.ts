//import { Pe } from '../shared/pe.model';
//import { Vraboten } from '../shared/vraboten.model';
import { Smetka } from './smetka.model'

export class Doc {
    public id?: number
    public docDate: string
    public vidDocument: number
    public presmetkovnaEdId: number
    public peNumber?: number
    public presmetkovnaName?: string
    public vrabotenId: number
    public vrabotenFullName?: string
    public vrabotenMb?: string
    public zabeleska?: string;
    public totalSmetki?: number
    public denIzvodId: number
    public denSmetki: Smetka[];




    constructor(docDate: string, vidDocument: number, presmetkovnaEdId: number, 
        vrabotenId: number,  denIzvodId: number, zabeleska: string, denSmetki: Smetka[],) {
            //this.id = id;
            this.docDate = docDate;
            this.vidDocument = vidDocument;
            this.presmetkovnaEdId = presmetkovnaEdId;
            //this.peNumber = peNumber;
            //this.presmetkovnaName = presmetkovnaName;
            this.vrabotenId = vrabotenId;
            //this.vrabotenFullName = vrabotenFullName;
            //this.vrabotenMb = vrabotenMb;
            //this.totalSmetki = totalSmetki;
            this.denIzvodId = denIzvodId;
            this.zabeleska = zabeleska;
            this.denSmetki = denSmetki;
            //this.totalSmetki = this.smetki.map(x => x.smetkaSum).reduce((a, b) => a + b )
    }


}




