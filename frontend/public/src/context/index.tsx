import { createContext } from 'react';
import { TopIngredient } from '../types/TopIngredient';

export const TopIngredientContext = createContext<TopIngredient[]>([]);