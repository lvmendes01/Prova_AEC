



export class User {
  nome?: string
  login?: string
  senha?: string
  perfil?: Perfil
  ativo?: boolean
  id?: string;
  token?: string;
}

export class UserLogin {
  login?: string
  senha?: string
}
export class Perfil {
  nome?: string
  permissoes: Permiss[] | undefined
  id?: number
}

export class Permiss {
  nome?: string
  url?: string
  id?: string
}