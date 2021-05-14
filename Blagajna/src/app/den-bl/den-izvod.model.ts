import { Doc } from "./doc.model"

export class DenIzvod {
    public id?: number
    public izvodDate: string
    public vkupnaIsplata: number
    public vkupenPriem: number
    public saldo: number
    public denBlSostojba: number
    public finalIzvod: boolean
    public denDocuments?: Doc[]

     constructor( izvodDate: string, vkupnaIsplata: number, vkupenPriem: number,
    saldo: number, denBlSostojba: number, finalIzvod: boolean) {
         
        this.izvodDate = izvodDate;
        this.vkupnaIsplata = vkupnaIsplata;
        this.vkupenPriem = vkupenPriem;
        this.saldo = saldo;
        this.denBlSostojba = denBlSostojba;
        this.finalIzvod = finalIzvod

        
     }
}

