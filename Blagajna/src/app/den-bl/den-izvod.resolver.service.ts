import { Injectable } from "@angular/core";
import {  ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";

import { DenBlService } from "./den-bl.service";
import { DenIzvod } from "./den-izvod.model";


@Injectable({providedIn: 'root'})
export class DenIzvodResolverService implements Resolve<DenIzvod> {
    constructor(private denBlService: DenBlService) {
        
    }

    resolve(route:  ActivatedRouteSnapshot, state: RouterStateSnapshot) {
       return this.denBlService.getDenIzvod();
    }
}