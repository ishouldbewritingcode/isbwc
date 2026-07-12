export interface Site {
  siteId: string;
  name: string | null;
  title: string | null;
  subTitle: string | null;
  design: string | null;
  footer1: string | null;
  footer2: string | null;
  footer3: string | null;
  footer4: string | null;
  metaDescription: string | null;
  metaImagePath: string | null;
  onAllPages: string | null;
  bodyTop: string | null;
  bodyBottom: string | null;
  imageFileName: string | null;
  faviconUrl: string | null;
  createdOn: string;
  updatedOn: string | null;
}

export interface NavItem {
  pageId: string;
  parentId: string | null;
  sort: number;
  navTitle: string | null;
  title: string | null;
  shortcut: string | null;
  children: NavItem[];
}
