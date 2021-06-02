import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ComponentsReteComponent } from "./components-rete/components-rete.component";
import { NovedadesReteComponent } from "./modulos/novedades-rete/novedades-rete.component";
import { UvtReteComponent } from "./modulos/uvt-rete/uvt-rete.component";
import { DeducionesComponent} from "./modulos/deduciones/deduciones.component";
import { VariablesReteComponent } from "./modulos/variables-rete/variables-rete.component";
import { RentaExentaComponent } from "./modulos/renta-exenta/renta-exenta.component";
const routes: Routes = [
   
    {
        path: '',
        data: { pageTitle: 'home' },
        component: ComponentsReteComponent
    },
    {
        path: 'uvt',
        data: { pageTitle: 'UnidadDeValorTributario' },
        component: UvtReteComponent
    },{
        path: 'variables',
        data: { pageTitle: 'Variables' },
        component: VariablesReteComponent
    }
    ,{
        path: 'novedades',
        data: { pageTitle: 'Novedades' },
        component: NovedadesReteComponent
    }
    ,{
        path: 'novedades/:id',
        data: { pageTitle: 'Novedades' },
        component: NovedadesReteComponent
    },
    {
        path: 'deduciones',
        data: { pageTitle: 'Deduciones' },
        component: DeducionesComponent
    },
    {
        path: 'renta-exenta',
        data: { pageTitle: 'Renta Exenta' },
        component: RentaExentaComponent
    },
]


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}