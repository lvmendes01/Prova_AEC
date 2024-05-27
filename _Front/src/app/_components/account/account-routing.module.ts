import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LayoutComponent } from './layout.component';
import { LoginComponent } from './login.component';
import { UsuarioComponent } from '../usuario/usuario.component';
import { ListaEnderecoComponent } from '../endereco/lista-endereco/lista-endereco.component';

const routes: Routes = [
    {
        path: '', component: LayoutComponent,
        children: [
            { path: 'login', component: LoginComponent },
            { path: 'usuario', component: UsuarioComponent },
            { path: 'enderecos', component: ListaEnderecoComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AccountRoutingModule { }
