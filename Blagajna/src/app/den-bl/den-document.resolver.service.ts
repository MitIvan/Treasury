import { Injectable } from "@angular/core";
import {  ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";

import { DenBlService } from "./den-bl.service";
import { Doc } from "./doc.model";

@Injectable({providedIn: 'root'})
export class DenDocumentsResolverService implements Resolve<Doc[]> {
    constructor(private denBlService: DenBlService) {
        
    }

    resolve(route:  ActivatedRouteSnapshot, state: RouterStateSnapshot) {
       return this.denBlService.getDenDocuments();
    }
}