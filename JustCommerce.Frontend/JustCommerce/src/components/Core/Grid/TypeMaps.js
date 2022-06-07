const filterTypeMap = [
  {
    text: 'NOT EMPTY',
    value: 'notEmpty'
  },
  {
    text: 'NOT NULL',
    value: 'notEmpty'
  },
  {
    text: 'EMPTY',
    value: 'empty'
  },
  {
    text: 'NULL',
    value: 'empty'
  },
  {
    text: 'CONTAINS',
    value: 'contains'
  },
  {
    text: 'DOES_NOT_CONTAIN',
    value: 'notcontains'
  },
  {
    text: 'EQUAL',
    value: '='
  },
  {
    text: 'NOT_EQUAL',
    value: '<>'
  },
  {
    text: 'GREATER_THAN',
    value: '>'
  },
  {
    text: 'GREATER_THAN_OR_EQUAL',
    value: '>='
  },
  {
    text: 'LESS_THAN',
    value: '<'
  },
  {
    text: 'LESS_THAN_OR_EQUAL',
    value: '<='
  },
  {
    text: 'STARTS_WITH',
    value: 'startswith'
  },
  {
    text: 'ENDS_WITH',
    value: 'endswith'
  },
  {
    text: 'BETWEEN',
    value: 'between'
  }
]

const filterOperationsMap = [
  {
    type: 'string',
    filterOperators: [
      'contains',
      'notcontains',
      'startswith',
      'endswith',
      '=',
      '<>',
      'empty',
      'notEmpty'
    ]
  },
  {
    type: 'number',
    filterOperators: ['=', '<>', '<', '>', '<=', '>=', 'between', 'empty', 'notEmpty']
  },
  {
    type: 'datetime',
    filterOperators: ['=', '<>', '<', '>', '<=', '>=', 'between', 'empty', 'notEmpty']
  }
]

export { filterTypeMap, filterOperationsMap }
