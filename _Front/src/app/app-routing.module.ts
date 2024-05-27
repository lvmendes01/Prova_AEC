import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { AuthGuard } from './_helpers';
import { HomeComponent } from './_components/home';
import { ListaUsuarioComponent } from './_components/usuario/lista-usuario/lista-usuario.component';
import { ListaEnderecoComponent } from './_components/endereco/lista-endereco/lista-endereco.component';
import { EnderecoComponent } from './_components/endereco/endereco.component';
import { UsuarioComponent } from './_components/usuario/usuario.component';

const accountModule = () => import('./_components/account/account.module').then(x => x.AccountModule);

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'usuariocadastro',  component: UsuarioComponent },
    { path: 'usuario',  component: ListaUsuarioComponent, canActivate: [AuthGuard] },
    { path: 'enderecocadastro',  component: EnderecoComponent, canActivate: [AuthGuard] },
    { path: 'enderecocadastro/:id',  component: EnderecoComponent, canActivate: [AuthGuard] },
    { path: 'endereco',  component: ListaEnderecoComponent, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
