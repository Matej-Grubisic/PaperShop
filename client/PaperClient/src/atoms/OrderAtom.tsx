import {atom} from "jotai";
import {Order} from "../Api.ts";

export const OrdersAtom = atom<Order[]>([]);
export const OrderAtom = atom<Order>();