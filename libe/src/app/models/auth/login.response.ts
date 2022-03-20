export interface UserResponseModel {
  user: User
  jwt: string
}

export interface User {
  id: number
  userName: string
  normalizedUserName: string
  email: string
  normalizedEmail: string
  emailConfirmed: boolean
  passwordHash: string
  securityStamp: string
  concurrencyStamp: string
  phoneNumber: string
  phoneNumberConfirmed: boolean
  twoFactorEnabled: boolean
  lockoutEnd: string
  lockoutEnabled: boolean
  accessFailedCount: number
  fullName: string
  role: Role
  profile: Profile
}

export interface Role {
  id: number
  name: string
  normalizedName: string
  concurrencyStamp: string
}

export interface Profile {
  id: number
  cantry: string
  city: string
  bearthday: string
}
