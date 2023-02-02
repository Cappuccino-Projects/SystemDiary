import React from 'react'

export const themes = {
  default: 'default',
  dark: 'dark'
}

export const userContext = {
  theme: themes.default,
} 

export const UserContext = React.createContext();