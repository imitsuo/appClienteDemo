import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ClientComponent } from './components/client/client.component';
import { ClientDetailComponent } from './components/client/client-detail/client-detail.component';
import { ClientService } from './components/client/shared/client.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ClientComponent,
        ClientDetailComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'clients', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'clients', component: ClientComponent  },
            { path: 'clients/:c', component: ClientComponent  },
            { path: 'client/new', component: ClientComponent },
            { path: 'client/:id', component: ClientComponent }
            //,  { path: '**', redirectTo: 'home' }
        ])
    ],    
    providers: [
        ClientService
    ]
})
export class AppModuleShared {
}
