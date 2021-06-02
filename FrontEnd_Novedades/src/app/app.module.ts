import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsReteComponent } from './components-rete/components-rete.component';
import { MenuReteComponent } from './modulos/menu-rete/menu-rete.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { UvtReteComponent } from './modulos/uvt-rete/uvt-rete.component';
import { VariablesReteComponent } from './modulos/variables-rete/variables-rete.component';
import { NovedadesReteComponent } from './modulos/novedades-rete/novedades-rete.component';
import { AppRoutingModule } from './app.routing.module';
import { RouterModule, Routes } from '@angular/router';
import { MatSelectModule } from '@angular/material/select';
import { ModalModule } from 'ngx-bootstrap/modal';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import {MatInputModule} from '@angular/material/input';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { NovedadService } from './services/novedades.service';
import { deducionesService } from './services/deduciones.service';
import { ConceptoService } from './services/concepto.service';
import { EmpleadosService } from './services/empleados.service';
import { NgSelectModule } from '@ng-select/ng-select';
import {MatDatepicker, MatDatepickerModule} from '@angular/material/datepicker';
import {MatTabsModule} from '@angular/material/tabs';
import {MatRadioModule} from '@angular/material/radio';
import {MatBadgeModule} from '@angular/material/badge';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { DateAdapter, MatNativeDateModule, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { VariablesService } from './services/variables.services';
import { BsDatepickerModule, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { DATE } from 'ngx-bootstrap/chronos/units/constants';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { DeducionesComponent } from './modulos/deduciones/deduciones.component';
import { RentaExentaComponent } from './modulos/renta-exenta/renta-exenta.component'
import { rentaexentaService } from './services/renta-exenta.service';


@NgModule({
  declarations: [
    AppComponent,
    ComponentsReteComponent,
    MenuReteComponent,
    UvtReteComponent,
    VariablesReteComponent,
    NovedadesReteComponent,
    DeducionesComponent,
    RentaExentaComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    AppRoutingModule,
    RouterModule, 
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    MatDialogModule,
    ModalModule.forRoot(),
    MatSelectModule,
    HttpClientModule,
    PaginationModule.forRoot(),
    MatPaginatorModule,
    FormsModule,
    MatInputModule,
    NgSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTabsModule,
    MatRadioModule,
    MatBadgeModule,
    MatSlideToggleModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    MatNativeDateModule,
    FormsModule,
    
    
    
    

    
  ],
  providers: [
    {provide:MAT_DATE_LOCALE, useValue: 'es-ES'},
    MatIconRegistry,NovedadService, 
    ConceptoService,EmpleadosService , 
    MatDatepickerModule,MatDatepicker,MatNativeDateModule,BsLocaleService,
    VariablesService,deducionesService , rentaexentaService,
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps:[MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
    },
    {provide:MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
    { provide: LocationStrategy, useClass: HashLocationStrategy }
  ],
  bootstrap: [AppComponent]


  
})
export class AppModule { }
