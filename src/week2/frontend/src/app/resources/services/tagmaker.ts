export function tagMaker(tagList: string): string[] {
  // split the string into an array with, get rid of empty strings, no duplicates, converted to lower case
  //  return tagList.split(' ').filter((tag, index, self) => tag && self.indexOf(tag) === index).map(tag => tag.toLowerCase());
  const parts = tagList
    .split(' ')
    .filter((t) => t !== '')
    .map((t) => t.trim())
    .map((t) => t.toLowerCase());

  return Array.from(new Set(parts));
}
