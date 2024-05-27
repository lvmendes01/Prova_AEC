import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// used to create fake backend
import { fakeBackendProvider } from './_helpers';

import { AppRoutingModule } from './app-routing.module';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { AppComponent } from './app.component';
import { AlertComponent } from './_components/alert';
import { UsuarioComponent } from './_components/usuario/usuario.component';
import { ListaUsuarioComponent } from './_components/usuario/lista-usuario/lista-usuario.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ListaEnderecoComponent } from './_components/endereco/lista-endereco/lista-endereco.component';
import { EnderecoComponent } from './_components/endereco/endereco.component';

@NgModule({
    imports: [
        FormsModule,
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule,
        FontAwesomeModule
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        UsuarioComponent,
        ListaUsuarioComponent,
        EnderecoComponent,
        ListaEnderecoComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

        // provider used to create fake backend
        fakeBackendProvider
    ],
    bootstrap: [AppComponent]
})
export class AppModule { };
