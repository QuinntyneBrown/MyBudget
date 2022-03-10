/* tslint:disable */
import { CostCenterDto } from './cost-center-dto';
export interface GetCostCenterByIdResponse {
  costCenter?: CostCenterDto;
  validationErrors?: Array<string>;
}
