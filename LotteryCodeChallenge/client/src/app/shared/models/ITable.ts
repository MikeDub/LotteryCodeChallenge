export interface ITable {
  columns: string[];
  data: any[];
}

export class DrawTable implements ITable {
  columns: string[];
  data: any[];
}
