import { Perfil } from "./user"

export class UsuarioModel {

    nome?: string
    login?: string
    senha?: string
    perfil: Perfil | undefined
    ativo?: boolean
    id?: string
}
export class UsuarioModelSalvar {

  usuario?: string
  nome?: string
  senha?: number

}

