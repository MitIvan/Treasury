import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { DenBlComponent } from "./den-bl/den-bl.component";
import { DevBlComponent } from "./dev-bl/dev-bl.component";
import { KasaIspComponent } from "./den-bl/kasa-isp/kasa-isp.component";
import { PrintKasaComponent } from "./den-bl/print-kasa/print-kasa.component";
import { DenIzvodComponent } from "./den-bl/den-izvod/den-izvod.component";
import { DenDocumentsResolverService } from "./den-bl/den-document.resolver.service";
import { DenIzvodResolverService } from "./den-bl/den-izvod.resolver.service";

const appRoutes: Routes = [
    {path:'', component: HomeComponent},
    {path:'denbl', component: DenBlComponent, resolve:[DenDocumentsResolverService, DenIzvodResolverService], children: [
        {path: 'new', component: KasaIspComponent, resolve:[DenDocumentsResolverService, DenIzvodResolverService]},
        {path: ':id', component: PrintKasaComponent, resolve:[DenDocumentsResolverService, DenIzvodResolverService]},
        {path: ':id/edit', component: KasaIspComponent, resolve:[DenDocumentsResolverService, DenIzvodResolverService]},
    ]},
    {path:'denizvod',resolve:[DenIzvodResolverService, DenDocumentsResolverService], component: DenIzvodComponent},
    { path: '**', pathMatch: 'full', component: HomeComponent }
    
]

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {

}