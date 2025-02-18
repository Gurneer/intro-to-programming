export type ResourceListItem = {
  id: string;
  title: string;
  description: string;
  link: string;
  linkText: string;
  createdBy: string;
  createdOn: string;
  tags: string[];
};

export type ResourceListItemCreateModel = Omit<
  ResourceListItem,
  'id' | 'createdOn' | 'createdBy' | 'tags'
> & { tags: string };
