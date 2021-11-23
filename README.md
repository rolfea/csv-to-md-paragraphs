# README

This is a quick proof of concept for a specific tool that my wife mentioned might be useful for her in a data entry project for her internship. 

This takes an input of a `.csv` file with a header and outputs a `.md` file where each row is transformed into a "paragraph" entry. 

Currently the formatting is simply to treat the first cell in the row as an H2 header and each subsequent row as an H3 after that. 

Her specific use-case relates to exporting a table from a OneNote notebook and generating a paragraph of text in a specific formatting per row of that table. This could likely be made more robust and resilient for a more generalized use-case in the future.

## To Run

To run, clone this repo, then, within the project directory, run:
```
dotnet build
dotnet run Program.cs test.csv output-file-name
```

Note, this will overwrite the output file if one already exists.

## To Do 

[x] ingest reasonably formatted csv
[x] output empty .md file
[x] output md with default template
[x] parse input into raw MD and insert into output template
  - skips header
[] parse basic formatting (bold, italic, etc.) from header values
[] override default header sizes from csv header values
[] swap bespoke templating with robust library (handlebars?)
[] swap csv ingestion with robust library
[] safer file handling
  - warn on file delete or append number to output file if collision  
[] unit tests