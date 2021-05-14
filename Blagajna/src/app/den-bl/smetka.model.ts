

export class Smetka {
    public id?: number
    public smetkaInfo: string;
    public smetkaDate: string;
    public smetkaTotal: number;
    public denDocumnetId?: number


    constructor(smetkaInfo: string, smetkaDate: string, smetkaTotal: number, ) {
        this.smetkaInfo = smetkaInfo;
        this.smetkaDate = smetkaDate;
        this.smetkaTotal = smetkaTotal;
    }
}