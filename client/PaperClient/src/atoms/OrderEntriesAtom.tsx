import {atom} from "jotai";
import {OrderEntry} from "../Api.ts";

export const OrderEntriesAtom = atom<OrderEntry[]>([]);