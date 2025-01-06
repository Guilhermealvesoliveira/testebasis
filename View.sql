
CREATE OR REPLACE VIEW teste_basis.vwlivrosdetalhes
AS SELECT l."CodL",
    l."Titulo",
    l."Edicao",
    l."AnoPublicacao",
    string_agg(DISTINCT a."Nome"::text, ', '::text) AS autores,
    string_agg(DISTINCT ass."Descricao"::text, ', '::text) AS assuntos
   FROM teste_basis."Livro" l
     LEFT JOIN teste_basis."Livro_Autor" la ON l."CodL" = la."CodL"
     LEFT JOIN teste_basis."Autor" a ON la."CodAu" = a."CodAu"
     LEFT JOIN teste_basis."Livro_Assunto" las ON l."CodL" = las."CodL"
     LEFT JOIN teste_basis."Assunto" ass ON las."CodAs" = ass."CodAs"
  GROUP BY l."CodL", l."Titulo", l."Edicao", l."AnoPublicacao";