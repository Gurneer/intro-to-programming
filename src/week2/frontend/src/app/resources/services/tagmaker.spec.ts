import { tagMaker } from './tagmaker';

describe('Making Tags', () => {
  it('Can Make Some Tags Simple', () => {
    const results = tagMaker('dog cat mouse');

    expect(results).toEqual(['dog', 'cat', 'mouse']);
  });

  it('Can Make Some Tags Duplicates', () => {
    const results = tagMaker('dog cat bear bear');
    // fix this
    expect(results).toEqual(['dog', 'cat', 'bear']);
  });

  it('Can Make Some Tags Empty should return an Empty Array', () => {
    const results = tagMaker('');

    expect(results).toEqual([]);
  });
  it('Can Make Some Tags Convert to Lower Case', () => {
    const results = tagMaker('DOG cat Bear');

    expect(results).toEqual(['dog', 'cat', 'bear']);
  });
  it('Strips out Extra Spaces', () => {
    const results = tagMaker('dog   cat   bird   ');
    expect(results).toEqual(['dog', 'cat', 'bird']);
  });
});
