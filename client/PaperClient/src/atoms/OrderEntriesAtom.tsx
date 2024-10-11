import {atom} from "jotai";
import {OrderEntry} from "../Api.ts";

export const OrderEntriesAtom = atom<OrderEntry[]>([]);

export const AllOrderEntriesAtom = atom<OrderEntry[]>([]);